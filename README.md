# Interfaces Inteligentes 04

## Exercise Prompts and Corresponding Code Files

### 1. Collision Mechanics with Shapes

#### Prompt
Create a mechanic where, upon collision between a cube and a cylinder, type 1 spheres move towards a predetermined type 2 sphere, and type 2 spheres move towards the cylinder. The cylinder must send a message upon collision, and the spheres should respond according to their group.

#### Description
This section implements collision detection between the cube and the cylinder, triggering movements of spheres based on their types when a collision occurs.

#### Files `CollisionDetector.cs` `Type1Spider.cs` `Type2Sphere.cs`
![Practica-IV-SampleScene-Windows_-Mac_-Linux-Unity-2022 3 48f1-_DX11_-2024-10-24-22-27-04](https://github.com/user-attachments/assets/df5e289a-6de6-4adb-b8fb-8d251dc8390c)

---

### 2. Implementing Spider Mechanics

#### Prompt
Replace the geometric objects with spiders for the spheres and an egg for the cylinder, which you can find in the provided link.

#### Description
This exercise involves replacing the geometric objects with spider models for the spheres and an egg for the cylinder. The provided link contains the models needed for the implementation.

#### Files: `CollisionDetector.cs` `Type1Spider.cs` `Type2Sphere.cs`
![Practica-IV-SampleScene-Windows_-Mac_-Linux-Unity-2022 3 48f1-_DX11_-2024-10-24-23-26-15](https://github.com/user-attachments/assets/71869617-5a92-48de-9eda-5c4dad4d7fec)

---

### 3. Implementing Spider Mechanics (2)

#### Prompt
Adapt the scene to include type 1 and type 2 spiders, as well as different types of eggs (type 1 and type 2). Type 1 spiders should move towards a designated object when type 2 spiders are hit.

#### Description
This task involves setting up the spider mechanics so that type 1 spiders react to collisions with type 2 spiders by moving towards a specified target.

#### Files `MultipleCollisionDetector.cs` `Type1Spider.cs` `Type1Spider.cs`
![copia 3 - Trim](https://github.com/user-attachments/assets/a27bfdf3-5c97-4dae-b6cb-22e1fc9e6bc4)

---

### 4. Egg Collection and Scoring

#### Prompt
Implement mechanics for egg collection that update the player's score. Type 1 spiders should add 5 points to the score, while type 2 spiders add 10 points. Display the score in the console.

#### Description
This section manages score tracking and updates based on egg collection by spiders, logging the total score to the console.

#### Files `SpiderScore.cs` `Egg.cs` `ScoreManager.cs`
![copia 4 - Trim](https://github.com/user-attachments/assets/2335714b-fb88-4459-ba59-df2fdeee653f)

---

### 5. Handling Spider Teleportation

#### Prompt
When the cube approaches a reference object, type 1 spiders should teleport to a pre-set target egg. Type 2 spiders should orient themselves towards a specific object placed in the scene for this purpose.

#### Description
This exercise implements a mechanic where type 1 spiders teleport and type 2 spiders orient towards a target, depending on the cube's position relative to a reference object.

#### Files `CubeCollisionSpiderController.cs` `SpiderEggCollector.cs` `SpiderEggLooker.cs`
---
![Practica-IV-SampleScene-Windows_-Mac_-Linux-Unity-2022 3 48f1_-_DX11_-2024-10-25-01-52-06](https://github.com/user-attachments/assets/323a1eb6-9979-4326-9f22-4f669319882a)


### 6. UI for Score Display

#### Prompt
Create a UI interface to show the score obtained by the cube using Unity's Canvas and Text components. The interface should dynamically update as the score changes.

#### Description
This task focuses on developing a UI that dynamically updates to display the player's score in real-time using Unity's Canvas system.

#### Files `EggMod.cs` `ScoreManagerMod.cs` `ScoreUi.cs`

![Practica-IV-SampleScene-Windows_-Mac_-Linux-Unity-2022 3 48f1_-_DX11_-2024-10-25-03-42-26](https://github.com/user-attachments/assets/f613f9d9-52e3-459c-83a8-a2d5af011769)

---

### 7. Reward System Implementation

#### Prompt
Implement a mechanic where every 100 points, the player receives a reward displayed in the UI. The reward should be visually distinct and appear on the screen whenever the player reaches the score milestone.

#### Description
This section sets up a reward system that triggers when the player reaches certain score milestones, updating the UI accordingly and providing feedback to the player.

#### Files `EggMod.cs` `ScoreManagerMod.cs` `ScoreUi.cs` 

![Practica-IV-SampleScene-Windows_-Mac_-Linux-Unity-2022 3 48f1_-_DX11_-2024-10-25-03-42-26](https://github.com/user-attachments/assets/c56e5206-eaf4-4a19-9178-1b9f9a3120d2)

---

### 8. Scene Setup with Prototype Elements

#### Prompt
Generate a scene that includes elements fitting the prototype's layout and incorporates some of the previous mechanics.

#### Description
This exercise involves setting up a scene that aligns with the initial prototype, while integrating some of the previously implemented game mechanics to create a cohesive environment.

#### Files
`MultipleCollisionDetector.cs`, `Type1Spider.cs`, `Egg.cs`

![copia 4 - Trim](https://github.com/user-attachments/assets/36e87e2e-14dd-447f-aafc-0870135d8ef9)

---

### 9. Implementing Exercise 3 with a Physical Cube

#### Prompt
Re-implement the mechanics from exercise 3, with the cube now being a physical object.

#### Description
This task revisits the mechanics from exercise 3, making the cube a rigidbody with physics-based interactions, which impacts how it collides with spiders and triggers their movements.

#### Files
`CollisionDetector.cs`, `Type1Spider.cs`, `CubeKeyControl.cs`

---
