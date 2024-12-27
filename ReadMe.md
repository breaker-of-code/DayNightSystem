## 27 Dec 2024
## Day-Night System

> Overview
> The Day-Night System dynamically simulates the progression of time in a 24-hour cycle, blending between day and night visuals while adjusting environmental lighting and skybox properties. 
Ideal for immersive worlds, this system integrates seamlessly with in-game clocks and other systems.

> Features
> Dynamic Skybox Blending. Smooth transitions between day and night cubemaps.
> Lighting Adjustments. Gradual intensity and color changes for sun and moonlight.
> Time Synchronization. Fully compatible with custom clock systems.

> Setup
> Attach the DayNightCycleManager script to a GameObject in your scene.
> Configure the following in the Inspector:
> Assign day and night skybox cubemaps.
> Link a directional light for sun and moon effects.
> Sync with your clock system to update the time of day.

> Usage
> Adjust cycle speed using the timeScale property.
> Blend factors update automatically based on the current hour.
> Call UpdateSkybox() and UpdateLighting() in your scripts if needed.

> Customization
> Replace cubemaps for unique day/night aesthetics.
> Extend the system with weather effects or seasonal cycles.