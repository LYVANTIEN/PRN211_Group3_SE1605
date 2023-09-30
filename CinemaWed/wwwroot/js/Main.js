$(".owl-carousel").owlCarousel({
  items: 1,
  loop: true,
  autoplay: true,
  autoplayTimeout: 3000,
  margin: 10,
  nav: false,
  responsive: {
    0: {
      items: 1,
    },
    600: {
      items: 1,
    },
    1000: {
      items: 1,
    },
  },
});

const dangchieu = document.querySelector("#dangchieu");
const sapchieu = document.querySelector("#sapchieu");
const sap_chieu = document.querySelector(".sap-chieu");
const dang_chieu = document.querySelector(".dang-chieu");
sapchieu.addEventListener("click", function () {
  dang_chieu.classList.add("d-none");
  sap_chieu.classList.remove("d-none");
});
dangchieu.addEventListener("click", function () {
  dang_chieu.classList.remove("d-none");
  sap_chieu.classList.add("d-none");
});
