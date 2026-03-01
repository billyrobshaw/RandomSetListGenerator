window.scrollLyricsSmooth = (id, pixels) => {
    const el = document.getElementById(id);
    if (!el) return;

    el.scrollTo({
        top: el.scrollTop + pixels,
        behavior: "smooth"
    });
};

window.resetLyricsScroll = (id) => {
    const el = document.getElementById(id);
    if (!el) return;

    el.scrollTo({
        top: 0,
        behavior: "auto"
    });
};

window.getScrollInfo = (id) => {
    const el = document.getElementById(id);
    if (!el) return null;

    return {
        scrollHeight: el.scrollHeight,
        clientHeight: el.clientHeight
    };
};
