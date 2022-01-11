# Popup block when mouse is over

This has 2 render fragments:
1. NormalDisplay: normally this is showd
2. PopupDisplay: this is displayed when mouse was over NormalDisplay

PopupDisplay is showed over the normal display, with absolute position, not instead.

## Usage
It uses javascript but it is loaded dynamically when it needed. No need to change main HTML layout header. PopupDisplay have to be greather or equal dimension that NormalDisplay has.

Usage example:
```csharp
<OnlyAti.Blazor.HoverPopup.HoverPopUp JSRuntime="js">
    <NormalDisplay>
        <div style="width: 250px; height: 100px; background-color: red;"></div>
    </NormalDisplay>
    <PopupDisplay>
        <div style="width: 300px; height: 400px; background-color: black; opacity: 0.7;"></div>
    </PopupDisplay>
</OnlyAti.Blazor.HoverPopup.HoverPopUp>
```

