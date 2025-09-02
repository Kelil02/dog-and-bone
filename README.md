# Dog & Bone (Unity test)

A tiny 2D game where you guide a dog to a bone, avoid walls, and manage master volume from a Settings menu.

---

## Tech Specs
- **Engine:** Unity **2022.3.44f1** (LTS)
- **Target:** Windows/Mac/Linux Desktop (tested in Editor)
- **Scenes:** `Assets/Scenes/MainMenu.unity`, `Assets/Scenes/Game.unity`
- **Audio:** `Assets/Audio/GameMixer.mixer` with an exposed **MasterVolume** parameter
- **Saves:** PlayerPrefs key **MasterVolume** (float 0.01–1.0)

---

## How to Run
1. Open the project in Unity **2022.3.44f1**.
2. Open **Assets/Scenes/MainMenu.unity**.
3. Press ▶️ (Play).  
   - **Start** → loads the **Game** scene.  
   - **Settings** → shows a Master Volume slider (persists between runs).  
   - **Quit** → exits the app (in a build).

> Make sure both **MainMenu** and **Game** are in **File → Build Settings → Scenes In Build** (MainMenu first).

---

## Controls
- **Left Mouse (hold):** Move the dog toward the cursor.
- **ESC:** Pause / open menu (where applicable).
- **R:** Retry after *Game Over* (if your platform input is set up like that).
- **Quit button:** Exits the application (in a build).

---

## Gameplay
- Reach the **bone** to **Win** (plays a one-shot “goal” sound).
- Touch a **wall** to trigger **Game Over** (Retry or Back to Menu).

---

## Audio (Master Volume)
- **Mixer:** `Assets/Audio/GameMixer.mixer`  
  Exposed parameter: **`MasterVolume`** (in dB).
- **Slider range:** linear 0.01 → 1.0 (no whole numbers).  
  Conversion: `dB = Mathf.Log10(linear) * 20f`, clamped **-80 dB … 0 dB**.
- **Persistence:** Current value is saved to **PlayerPrefs** under key `MasterVolume` and restored on load.

---

## Project Structure

Assets/
Audio/ # Mixer + clips (ambience, goal sound)
Scenes/ # MainMenu, Game
Scripts/ # GameManager, PlayerController, Settings UI helpers, etc.
Sprites/ # Dog, Bone, UI art
UI/ # Prefabs / panels used by menus


---


---

## Acceptance Checklist (what this build does)
- ✅ Opens in **2022.3.44f1** with no errors.
- ✅ Two scenes (**Main Menu**, **Game**) in Build Settings.
- ✅ **Start / Settings / Quit** work.
- ✅ **Master Volume** slider affects **all audio** and persists.
- ✅ Dog is **mouse-controlled**; touching a wall triggers **Game Over**.
- ✅ Reaching the bone triggers **Win** and plays the **goal sound once**.
- ✅ Repo has two branches and at least one PR from the work branch.

---

## Build
1. **File → Build Settings…**
2. Add **MainMenu** (first) and **Game**.
3. Choose target platform and **Build**.

---

## License
Educational sample. No license specified; treat as “all rights reserved” unless told otherwise.
