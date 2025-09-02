# Dog & Bone (Unity test)

## Unity version
- **2022.3.44f1**

## How to run
1. Open Unity Hub → Add project from disk → select this folder.
2. Open **Assets/Scenes/MainMenu.unity**.
3. Play (▶). From Main Menu press **Start** to load **Game** scene.

## Controls
- **Left Mouse**: move the dog toward the cursor.
- **Esc**: pause / open menu.
- **R**: retry after Game Over.
- **Quit** button: exits the app (in a build).

## Audio
- Uses an **AudioMixer** with a **Master** group.
- The **Settings → Master Volume** slider writes to exposed parameter `MasterVolume`.
- Range is **-80 dB to 0 dB**. 0 = full volume. -80 ≈ mute.
- The slider value is converted to dB with `Mathf.Log10(value) * 20` (value in 0–1).

## What I implemented
- Two scenes: **Main Menu** and **Game** (added to Build Settings).
- **Start / Settings / Quit** work.
- **Master Volume** slider affects all audio via AudioMixer.
- Dog is **mouse‑controlled**; touching a wall triggers **Game Over**.
- Reaching the bone triggers **Win** and plays a goal sound **once**.
- Basic UI and retry flow.
- Git branching: `main` (stable) and `<your-name>` (working).

## Known issues
- None major. Replace this with anything the reviewer should know.

## Repo notes
- Clear commit messages: explain **what** changed and **why**.
- Make at least **one Pull Request** from your working branch into `main`.

---

### Credits
Starter assets: yours or free placeholders. Sounds/images under permissive licenses.



## Implemented
- Two scenes: Main Menu (Scene 0) and Game (Scene 1) — both added to Build Settings.
- Start/Settings/Quit buttons work.
- Master Volume slider controls exposed mixer param `MasterVolume`.
- Dog is mouse-controlled; hitting a wall triggers Game Over.
- Picking the bone triggers Win and plays the goal sound once.
- Retry resets the scene; cursor shows/hides correctly between menu and game.

## Skipped
- Advanced SFX mixing per-sound (kept it to a single master).
- Mobile/touch UI (mouse only).

## Known issues
- First frame after retry, mouse might be briefly visible before lock.
- Audio mixer has a safe min at –80 dB (Unity’s floor); slider maps 0–1 to –80..0.
