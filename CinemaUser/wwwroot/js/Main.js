

    let dangchieuEle = document.querySelector("#dangchieu");
    let sapchieuEle = document.querySelector("#sapchieu");
    let sapchieuDiv = document.querySelector(".sap-chieu");
    let dangchieuDiv = document.querySelector(".dang-chieu");
    sapchieuEle.addEventListener("click", function () {
        dangchieuDiv.classList.add("d-none");
        sapchieuDiv.classList.remove("d-none");

    });
    dangchieuEle.addEventListener("click", function () {
        dangchieuDiv.classList.remove("d-none");
        sapchieuDiv.classList.add("d-none");
    });






