# Contributing to gitpush-mod projects

Thanks for the interest — these mods are all built by [Godimas101](https://github.com/Godimas101) and community input genuinely helps.

## The easiest ways to contribute

**Report a bug** or **request a feature** on the specific mod's repo. Every mod has its own **Issues** tab with pre-filled templates:

1. Go to the mod's repo (e.g. `github.com/gitpush-mod/se-infolcd-apex-update`)
2. Click **Issues** → **New issue**
3. Pick **Bug report** or **Feature request**
4. Fill in what the template asks — the more specific, the better

**Rate + comment on the mod** on its distribution page:
- Space Engineers + MechWarrior 5 mods → [Steam Workshop](https://steamcommunity.com/id/godimas/myworkshopfiles)

**Support on Patreon** — [patreon.com/Godimas101](https://patreon.com/Godimas101). Not required, always appreciated.

## Submitting code changes (pull requests)

Pull requests are welcome, especially for:

- Bug fixes with a clear reproduction case
- Compatibility patches for other mods
- Small, focused improvements

Before opening a PR:

1. Open an issue first so we can discuss the change (unless it's a trivial typo or crash fix)
2. Keep changes scoped — one PR per fix/feature
3. Test in-game before submitting
4. For Space Engineers mods: keep the mod client-side-only if the parent mod is client-side-only ([InfoLCD Apex Update](https://github.com/gitpush-mod/se-infolcd-apex-update) is a strict example)
5. For MechWarrior 5 mods: do NOT commit `Saved/`, `Intermediate/`, or `Build/` folders

## Ticket-first workflow (for maintainers + agents)

If you're an agent (Claude Code, Cursor, Copilot, etc.) working on a mod: **every task must be a ticket on that mod's project board BEFORE you touch anything**. See the `AGENTS.md` file in each mod repo for the specific rules.

## Licensing

All gitpush-mod repos are MIT-licensed. Contributions are made under the same license. **Attribution is required when redistributing or forking** — see individual repo `LICENSE` files for details.

## Code of Conduct

Be decent. See [`CODE_OF_CONDUCT.md`](CODE_OF_CONDUCT.md) if you need it spelled out.
