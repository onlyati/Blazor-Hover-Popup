export function HoverPopupGetWidth(e) {
    return document.getElementById(e).clientWidth;
}

export function HoverPopupGetHeight(e) {
    return document.getElementById(e).clientHeight;
}

export function HoverPopupSetWidth(e, n) {
    document.getElementById(e).style.width = n + "px";
}

export function HoverPopupSetHeight(e, n) {
    document.getElementById(e).style.height = n + "px";
    document.getElementById(e).style.lineHeight = n + "px";
}