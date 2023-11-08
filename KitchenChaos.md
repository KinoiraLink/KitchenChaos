# 创建项目

TODO：学习 URP 相关

 删除 URP Empty Template

 检查项目设置
  Project Settings-Graphics-Scriptable Render Pipeline Settings:URP-HighFidelity

  URP Global Settings ：默认

  Quality: Levels 删除前两项 Balanced、Performant

删除项目中 Settings-URP-Balanced-Renderer、URP-Balanced、URP-Performant-Renderer、URP-Performant

# Unity 布局
略

# Visual Studio
用的 vscode ，大部分略 

Visual Studio 安装 Viasfora

## 重构

Visual Studio 安装 Force UTF-8(No BOM)

# 命名规范
略

## 重构
  代码规范在这个博文上，课程学习按照作者的规范，个人编写自己的项目是私有变量用下划线表示私有变量

> https://kinoiralink.github.io/2023/09/26/CSharp%E6%8F%90%E7%A4%BA%E6%9C%AC/

# 导入 Assets

> https://unitycodemonkey.com/download.php?dt=kitchenChaosProjectFiles&lecture=Assets\
>
> 删除 kitchenChaos_Complete_Project

# 后处理

*正常情况下，后处理应该在收尾工作时处理*

将默认的 场景改名为 "GameScene"

新建一个 Plane "Floor" 重置 Transform Scale: 5 5 5 添加 "Floor" 材质

将 PlayerVisual、ClearCounter_Visual、CuttingCounter_Visual、Tomato_Visual、Cabbage_Visual、StoveCounter 加入场景中 均对准相机 

删除项目中 SampleSceneProfile

 Global Volume-Add Override-Tonemapping（色调映射）、Color Adjustments、Bloom（发光）、（镜头暗角 ）Vignette

 > https://youtu.be/bkPe1hxOmbI

 看自己需要 抗锯齿（Anti-Aliasing）

 URP-HighFidelity-Renderer-Add Renderer Feature-Screen Space Ambient Occiusion(阴影线条)

调整摄像机的位置

window--Rendering--Lighting  看自己需要

最后保存一下后处理文件 Global Volume 中

看自己需要 在自行调整

删除场景中除地板外的其他拖拽实体，保存场景

## 重构

# 代码

## 配置文件

### Global Volume
```yaml
Tonemapping: 
  Mode: Netural
Color Adjustments:
  Contrast: 20
  Saturation: 20
Bloom:
  Threshold: 0.95
  Intensity: 1
Vignette:
  Intensity: 0.25  
  Smoothness: 0.4
```
### Main Camera
```yaml
Transform:
  Position: 0 21.5 -21.3
  Rotation: 46 0 0
Projection:
  Field of View: 20
Rendering:
  Post Processing: true
  Anti-aliasing: No
```

### URP-HighFidelity-Renderer
```yaml
Post-Processing:
  Enabled: true
Screen Space Ambient Occiusion:
  Intensity: 4
  Radius: 0.3
  Direct Lighting Strength: 1
```

### URP-HighFidelity
```yaml
Rendering:
  Renderer List: URP-HighFidelity-Renderer
Quality:
  HDR: true
  Anti-Aliasing(MSAA): 8x
```