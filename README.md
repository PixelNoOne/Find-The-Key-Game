#  Find The Key — Unity Gameplay Prototype
**English** | [Русская версия](README_RU.md)

**Find The Key** is a small first-person gameplay prototype built in **2 days** to demonstrate core gameplay systems, clean event-driven architecture, interaction mechanics, and UI logic.  
The project serves as a portfolio piece for game development positions.

---

##  Features

###  Interaction System
- Player interaction based on raycasting  
- Furniture opening/closing  
- Object highlighting via additional material slot  
- Distance-based interaction validation  

###  Sowing / Planting System
- Planting seeds into pots  
- Distance & direction checks  
- Instantiation of new objects  
- Reward progress tracking  

###  Quest System
- ScriptableObject-driven quest data  
- Step-by-step quest progression  
- Events:
  - `OnQuestStarted`
  - `OnFirstQuestFinished`
  - `OnRewardProgress`
- Automatic transition to the next quest  

###  Reward Logic
- Spawns a key item after completing all quest steps  
- UI updates progress in real time  

###  Audio System
- Custom SoundManager component  
- Background music (OGG)  
- Adjustable volume  

###  Player & Camera
- Smooth FPS controller  
- Horizontal/vertical camera rotation  
- Interaction through camera-centered raycast  

---

##  Core Systems

### **1. PlayerInputSystem**
Handles all player interactions with the world.  
Uses raycasting and event-driven logic to remain fully decoupled from scene objects.

**Key responsibilities:**  
- Raycast detection  
- Highlighting interactive objects  
- Interaction events (`whenIOpen`, `onItemPickUp`, `onSow`)  
- Distance checks  
- Communication with **WorldFurniture**, **WorldPot**, **QuestManager**  

This system is the **bridge** between the player and all interactable elements.

---

### **2. WorldFurniture / Interactables**
Modular behaviour for all furniture types (wardrobe, chest, drawers).  
Each object follows the same interaction pattern but has its own animation and logic.

![Gif_1_Outline](https://github.com/user-attachments/assets/7b21a4d6-9759-4883-b2d5-f33d4b27a04f)

**Key responsibilities:**  
- Plays open/close animations  
- Controls interaction availability  
- Sends interaction events back to PlayerInputSystem  
- Supports outline/highlight materials  

Scalable: new furniture types can be added without modifying PlayerInputSystem.

---

### **3. SowManager (Planting System)**  
Responsible for creating the planting point and handing control to the growth system (SeedSow).

![Gif_3_Grow](https://github.com/user-attachments/assets/802356af-78f3-4a14-b365-22fad5c58c55)

**Key responsibilities:**  
- Subscribes to the `onSow` event from PlayerInputSystem  
- Instantiates a **PlantEmpty** object at the planting location  
- Assigns a **SeedSow** component, which fully handles all growth logic  
- Notifies QuestManager about progress  
- Does not control growth itself — only triggers the setup step  

SowManager serves as a lightweight connector, keeping planting modular while delegating all growth behaviour to **SeedSow**.

---

### **4. QuestManager**
Central controller for linear quest progression.

![Gif_2_Progress](https://github.com/user-attachments/assets/58dca869-b099-4400-9115-f92e457ae660)

**Key responsibilities:**  
- Loads quest data via ScriptableObjects  
- Sends UI updates (`OnQuestStarted`, `OnRewardProgress`)  
- Spawns key items / pots  
- Manages quest state machine  
- Coordinates with SowManager and PlayerInputSystem  

This system binds together all gameplay loops.

---

##  Tech Stack

| Component | Used |
|----------|-------|
| Engine | Unity 6.3 LTS (URP 17.3) |
| Language | C# |
| Architecture | Event-driven systems |
| Data | ScriptableObjects |
| Version Control | Git + GitHub |
| Assets | Custom 3D models & audio created by our team |

---
##  How to Run and play

Option 1
1. Clone the repository:
git clone https://github.com/PixelNoOne/Find-The-Key-Game.git
2. Open in **Unity 6.3 LTS**  
3. Open the scene **SampleScene**  
4. Press **Play**
5. WASD to move, E to interact.

Option 2
1. Download the build:
[Download Windows Build](https://github.com/PixelNoOne/Find-The-Key-Game/releases/download/v1.0/FindTheKey.zip)
2. Unzip the archive and run the exe file.

---

##  Team — GDebug Studio 

| Role | Name |
|------|------|
| Developer | PixelNoOne |
| Artist | HokageRin |
| Sound designer | Thule's Veil |

---

##  License

This project is provided **for evaluation purposes only**.  
All scripts, assets, models, and audio belong to the project authors and **may not be reused or redistributed** without explicit permission.

Full license text is available in the `LICENSE` file.

---

##  illustrations

<img width="1920" height="1080" alt="Image_5" src="https://github.com/user-attachments/assets/7fe572d4-8d9e-4ad2-9a6e-5f274636ad9f" />
<img width="1920" height="1080" alt="Image_3" src="https://github.com/user-attachments/assets/6fbc11d6-f3cd-443d-8fd9-65cab2e513d4" />
<img width="1920" height="1080" alt="Image_1" src="https://github.com/user-attachments/assets/9ade5202-e0f7-48d4-9da5-4419566fdd0e" />
