window.resetLyricsScroll = function (elementId) {
    const box = document.getElementById(elementId);
    if (!box) return;

    box.scrollTop = 0;
};


window.scrollLyricsSmooth = function (elementId, amount) {
    const box = document.getElementById(elementId);
    if (!box) return;

    box.scrollTop += amount;
};



