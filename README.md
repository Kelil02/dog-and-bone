# Dog & Bone — Work Log (branch: `kelil`)

This branch tracks what I built, what went wrong, how I fixed it, and what’s left.

---

## What I Implemented
- **Scenes**
  - `MainMenu` with **Start / Settings / Quit**
  - `Game` with dog, bone, walls, win/lose UI
- **Audio**
  - Created **GameMixer.mixer** with **Master** group.
  - Exposed **MasterVolume** parameter for global volume control.
  - Added **ambience** loop + **goal** one-shot on win.
- **Settings / Persistence**
  - Settings panel with a **Slider** bound to `MasterVolume`.
  - Slider range **0.01–1.0**, `wholeNumbers = false`.
  - Save to **PlayerPrefs** (`MasterVolume`) and load on start.
- **Gameplay Code / UI**
  - Dog moves toward mouse **while LMB is held**.
  - **Game Over** on wall collision.
  - **Win** on bone collision (goal sound plays once).
  - **Retry / Back to Menu** buttons.
- **Scripts (high level)**
  - `MainMenu.cs` — handles Start/Settings/Quit.
  - `SettingsMenu.cs` — binds slider, saves/loads PlayerPrefs, sets mixer dB:
    ```csharp
    float dB = Mathf.Clamp(Mathf.Log10(linear) * 20f, -80f, 0f);
    masterMixer.SetFloat("MasterVolume", dB);
    ```
  - `GameManager.cs` — win/lose state, retry/menu transitions.
  - `PlayerController.cs` — dog movement toward cursor.
  - Helpers: `VolumeInitializer.cs`, `ResetVolumeOnce.cs`, etc.

---

## What Happened (Issues & Fixes)

### 1) Volume slider didn’t change audio
- **Cause:** Slider wasn’t wired to the script/mixer, and its range/wholeNumbers were wrong.
- **Fix:**
  - Set `wholeNumbers = false`, `minValue = 0.01`, `maxValue = 1.0`, `value = 1.0`.
  - Hook **On Value Changed (float)** → `SettingsMenu.OnSliderChanged(float)`.
  - Convert linear → dB with `Mathf.Log10(linear) * 20f`, clamp to [-80, 0].
  - Save to PlayerPrefs and call `Apply()` on load.

### 2) Cursor sometimes invisible after **Retry**
- **Cause:** Cursor state not restored when switching UI/game states in Editor.
- **Fix/Workaround:**
  - Ensure menus force:  
    ```c#
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    ```
  - In Editor, opening the menu also re-shows it; builds are fine.

### 3) Accidentally deleted **WinPanel**
- **Fix:** Recreated it (`UI → Panel` + text/buttons) and re-wired to `GameManager` events.

### 4) Git line-ending warnings (LF → CRLF)
- **Symptom:** Lots of `LF will be replaced by CRLF` during commit.
- **What it means:** Windows normalized line endings; Unity is okay with it.
- **Optionally normalize for everyone:**
  - Add a top-level **.gitattributes**:
    ```
    * text=auto
    *.cs text eol=lf
    *.meta text eol=lf
    *.unity text eol=lf
    *.shader text eol=lf
    *.asset text eol=lf
    ```
  - Or set once: `git config core.autocrlf true` (Windows).

---

## How To Test (quick)
1. Open `MainMenu` and hit ▶️.
2. Open **Settings** and drag the slider—volume should change immediately.
3. **Start**, Click left mouse to move the dog; hit a wall to see **Game Over**.
4. **Retry**; if cursor hides in Editor, open menu to re-show (known quirk).
5. Reach the bone → **Win** (hear the goal sound once).

---

## Done vs. Skipped
- **Done:** Mouse control, win/lose, mixer, persistent master volume, menus, one-shot win sound.
- **Skipped/Minimal:** No level progression, no mobile controls, no localization, minimal art/audio, Timer/best time, a second maze or difficulty toggle.

---

## Known Issues / Next Steps
- **Editor-only cursor quirk** after Retry (see above).

---
