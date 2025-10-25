const goUpBtn = document.getElementById("goUpBtn");

window.addEventListener("scroll", () => {
    if (window.scrollY < 200) {
        goUpBtn.classList.add("d-none");
    } else {
        goUpBtn.classList.remove("d-none");
    }
});

goUpBtn.addEventListener("click", () => {
    window.scrollTo({
        top: 0,
        behavior: "smooth"
    });
});
