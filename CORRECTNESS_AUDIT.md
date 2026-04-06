# Correctness Audit (2026-04-06)

## What was checked

- Attempted to build the solution with:
  - `msbuild baseProject.sln /t:Build /p:Configuration=Debug`
  - `xbuild baseProject.sln /p:Configuration=Debug`
- Verified project-file references in `base/baseProject.csproj` against files that actually exist in the repository.
- Reviewed critical runtime files for common correctness issues:
  - `base/Global.asax.cs`
  - `base/Site1.Master.cs`
  - `base/home.aspx.cs`
  - `base/app_data/SqlDBHelper.cs`

## Findings

1. **Build tooling is unavailable in the current environment.**  
   The repository cannot be compiled here because `msbuild`, `xbuild`, and `dotnet` are not installed.

2. **The project file references many missing page files (blocking build/runtime correctness).**  
   `base/baseProject.csproj` includes **27** non-existent files under `base/pages/user/*` (both `.aspx` and code-behind/designer files).

3. **Session key mismatch leads to inconsistent username behavior.**  
   - `Session_Start` sets `Session["user"]` in `Global.asax.cs`.
   - Other pages read `Session["Username"]` (e.g., `home.aspx.cs`, `Site1.Master.cs`).
   This mismatch can cause the site to always fall back to visitor behavior.

4. **Database helper executes raw SQL strings directly.**  
   `SqlDBHelper` methods accept raw SQL and run it directly, which is vulnerable to SQL injection if caller code concatenates user input.

5. **Runtime DB coupling is fragile.**  
   `SqlDBHelper.GetConnectionString()` auto-picks the first `.mdf` from `App_Data`, while `Web.config` also defines a named connection string. Divergence between the two can cause hard-to-debug environment issues.

## Improvement plan to ensure code runs correctly

### High priority (fix first)

1. **Repair project-file integrity**
   - Either restore the missing `base/pages/user/*` files, or
   - Remove all stale `<Content Include=...>` and `<Compile Include=...>` entries for missing files from `base/baseProject.csproj`.

2. **Standardize session keys across the app**
   - Pick one key (`"Username"` recommended) and update `Global.asax.cs` / page code-behind files consistently.

3. **Use parameterized SQL in `SqlDBHelper` callers (or helper overloads)**
   - Replace string-concatenated SQL with parameterized commands to prevent injection and conversion bugs.

### Medium priority

4. **Use one source of truth for DB connection settings**
   - Prefer `Web.config` connection strings and read them through `ConfigurationManager.ConnectionStrings[...]`.

5. **Add CI build validation**
   - Add a CI workflow that restores packages and builds the solution in a Windows/.NET Framework-compatible runner.

6. **Add minimal smoke tests**
   - Include at least one request-level smoke test for key pages (`home.aspx`, `pages/galery.aspx`) and one DB round-trip check.

### Low priority

7. **Harden global error handling**
   - Implement `Application_Error` logging and structured diagnostics.

8. **Tighten repository hygiene**
   - Remove committed build artifacts (`bin/`, `obj/`) from source control and add a `.gitignore` to prevent future drift.
