// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const scrollItems = document.getElementById("scroll-items");
const leftScroll = document.getElementById("scroll-left");
const rightScroll = document.getElementById("scroll-right");
const box = document.querySelectorAll(".box");

leftScroll.addEventListener("click", () => {
  scrollItems.scrollBy(-scrollItems.clientWidth, 0);
});
rightScroll.addEventListener("click", () => {
  scrollItems.scrollBy(scrollItems.clientWidth - 200, 0);
});

scrollItems.addEventListener("scroll", () => {
  if (scrollItems.scrollLeft == 0) leftScroll.style.display = "none";
  else leftScroll.style.display = "block";
  if (
    scrollItems.scrollWidth - scrollItems.clientWidth ==
      scrollItems.scrollLeft ||
    scrollItems.scrollWidth - scrollItems.clientWidth ==
      scrollItems.scrollLeft + 1 ||
    scrollItems.scrollWidth - scrollItems.clientWidth ==
      scrollItems.scrollLeft - 1
  )
    rightScroll.style.display = "none";
  else rightScroll.style.display = "block";
  console.log(
    `left : ${scrollItems.scrollLeft} full-width: ${
      scrollItems.scrollWidth - scrollItems.clientWidth
    }`
  );
});

scrollItems.addEventListener("click", (event) => {
  sessionStorage.setItem("scrolled", `${scrollItems.scrollLeft}`);
  box.forEach(() => {
    if (event.target.dataset.id === "all") {
      setReloadStatus(event.target.dataset.id);
      location.reload();
    } else {
      setReloadStatus(event.target.dataset.id);
      location.reload();
    }
  });
  scrollItems.childNodes.forEach((element) => {
    if (element.nodeName == "DIV") {
      if (
        element.dataset.id === event.target.dataset.id ||
        element.firstChild.dataset.id === event.target.dataset.id
      ) {
        sessionStorage.setItem("clickedLink", `${element.dataset.id}`);
      }
    }
  });
});

function setReloadStatus(event) {
  sessionStorage.setItem("reloading", "true");
  sessionStorage.setItem("event", `${event}`);
}

function disableLink() {
  let count = 0;
  var event = sessionStorage.getItem("event");
  var clickedLink = sessionStorage.getItem("clickedLink");
  var scrolled = sessionStorage.getItem("scrolled");
  box.forEach((element) => {
    if (event === "all") return;
    element.dataset.id != event
      ? element.parentElement.removeChild(element)
      : count++;
  });

  parseInt(scrolled) > 0 ? scrollItems.scrollTo(parseInt(scrolled), 0) : "";
  scrollItems.childNodes.forEach((element) => {
    if (element.nodeName == "DIV") {
      element.dataset.id === clickedLink
        ? (element.style.backgroundColor = "#ebf0fa")
        : (element.style.backgroundColor = "transparent");
    }
  });
  sessionStorage.clear();
}
window.onload = function () {
  var reloaded = sessionStorage.getItem("reloading");
  if (reloaded) {
    sessionStorage.removeItem("reloading");
    disableLink();
  }
};
