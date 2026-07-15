# AGENTS.md — gitpush-mod/.github

Special repo for the [`gitpush-mod`](https://github.com/gitpush-mod) GitHub org. Not a mod itself — it hosts the **org profile page** and **default community health files** (issue templates, CONTRIBUTING, CODE_OF_CONDUCT) that any mod repo without its own copies inherits.

> Parent context: `mods/AGENTS.md` (universal mod-repo rules)

## What's in this repo

- **`profile/README.md`** — renders at [github.com/gitpush-mod](https://github.com/gitpush-mod). Style-guide compliant, capsule-render `blur` header, mod grid, Patreon Support section.
- **`.github/ISSUE_TEMPLATE/bug_report.md`** — shared bug-report template (SE or MW5)
- **`.github/ISSUE_TEMPLATE/feature_request.md`** — shared feature-request template
- **`.github/ISSUE_TEMPLATE/config.yml`** — disables blank issues, adds Steam Workshop / Nexus Mods / Patreon contact links
- **`.github/CONTRIBUTING.md`** — how to contribute across mods
- **`.github/CODE_OF_CONDUCT.md`** — standard COC
- `LICENSE`, `.gitignore`, `README.md` — housekeeping

## How defaults work

GitHub picks up files in a special `.github` repo as **org-wide defaults**. Any repo in `gitpush-mod` that doesn't have its own copy of an issue template, CONTRIBUTING, or CODE_OF_CONDUCT inherits the one here. Mod-specific overrides live in each mod's own `.github/` folder.

## For agents

- **This repo is small on purpose.** Do not add mod-specific content here — that belongs on the mod's own repo.
- **Do not delete** `profile/README.md` — it's what renders the org landing page.
- **Style guide:** [`Godimas101/personal-projects/docs/style-guides/README_STYLE_GUIDE.md`](https://github.com/Godimas101/personal-projects/blob/main/docs/style-guides/README_STYLE_GUIDE.md) — the `Org profile` family uses the `blur` capsule type.
- **Repo family reference:** [`REPO_FAMILY.md`](https://github.com/Godimas101/personal-projects/blob/main/docs/style-guides/REPO_FAMILY.md) — canonical mapping of capsule types per repo.

## Where work lives (RULE — non-negotiable)

Changes to this repo are usually tracked on the **[Personal Projects board](https://github.com/users/Godimas101/projects/2)** (since it's cross-org infrastructure, not a mod), not on any per-mod board.

- **Starting work?** Open a ticket on the Personal Projects board first.
- **Finished?** Close with a summary comment (what you did / problems + solutions / anything NOT done).

## MUST NOT

- Add mod-specific templates here (they belong on the mod repo)
- Rename `profile/` or `profile/README.md` (GitHub convention — required for the org landing page to work)
- Enable "blank issues" in `config.yml` (they defeat the point of templates)

## Related

- Org landing page: <https://github.com/gitpush-mod>
- Personal profile equivalent: [`Godimas101/Godimas101`](https://github.com/Godimas101/Godimas101) (the personal user profile)
- Style guide: [`README_STYLE_GUIDE.md`](https://github.com/Godimas101/personal-projects/blob/main/docs/style-guides/README_STYLE_GUIDE.md)
