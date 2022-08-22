// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Hamburger menu click action
function toggleMobileMenu(menubar) {
  menubar.classList.toggle("open");
}

class Ui {
  constructor(
    scrollItems,
    leftScrollIcon,
    rightScrollIcon,
    box,
    textBox,
    maxWidth
  ) {
    this.scrollItems = scrollItems;
    this.leftScrollIcon = leftScrollIcon;
    this.rightScrollIcon = rightScrollIcon;
    this.box = box;
    this.textBox = textBox;
    this.maxWidth = maxWidth;
  }

  initializeDomInternContent() {
    this.leftScrollIcon.addEventListener("click", () => {
      this.scrollItems.scrollBy(-this.scrollItems.clientWidth, 0);
    });
    this.rightScrollIcon.addEventListener("click", () => {
      this.scrollItems.scrollBy(this.scrollItems.clientWidth - 200, 0);
    });
    this.scrollItems.addEventListener("scroll", () => {
      if (this.scrollItems.scrollLeft == 0)
        this.leftScrollIcon.style.display = "none";
      else this.leftScrollIcon.style.display = "block";
      // Checks whether scrollbar has reached Maximum Limit
      // addition and subtraction of 1 due to different screen sizes
      if (
        this.scrollItems.scrollWidth - this.scrollItems.clientWidth ==
          this.scrollItems.scrollLeft ||
        this.scrollItems.scrollWidth - this.scrollItems.clientWidth ==
          this.scrollItems.scrollLeft + 1 ||
        this.scrollItems.scrollWidth - this.scrollItems.clientWidth ==
          this.scrollItems.scrollLeft - 1
      )
        this.rightScrollIcon.style.display = "none";
      else this.rightScrollIcon.style.display = "block";
    });
    this.scrollItems.addEventListener("click", (event) => {
      sessionStorage.setItem("scrolled", `${this.scrollItems.scrollLeft}`);
      this.box.forEach(() => {
        if (event.target.dataset.id === "all") {
          setReloadStatus(event.target.dataset.id);
          location.reload();
        } else {
          setReloadStatus(event.target.dataset.id);
          location.reload();
        }
      });
      this.scrollItems.childNodes.forEach((element) => {
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
    const renderItems = () => {
      var event = sessionStorage.getItem("event");
      var clickedLink = sessionStorage.getItem("clickedLink");
      var scrolled = sessionStorage.getItem("scrolled");
      parseInt(scrolled) > 0
        ? this.scrollItems.scrollTo(parseInt(scrolled), 0)
        : "";
      this.box.forEach((element) => {
        if (event === "all") return;
        element.dataset.id != event
          ? element.parentElement.removeChild(element)
          : "";
      });

      this.scrollItems.childNodes.forEach((element) => {
        if (element.nodeName == "DIV") {
          element.dataset.id === clickedLink
            ? (element.style.backgroundColor = "#ebf0fa")
            : (element.style.backgroundColor = "transparent");
        }
      });
      sessionStorage.clear();
    };
    window.onload = function () {
      var reloaded = sessionStorage.getItem("reloading");
      if (reloaded) {
        sessionStorage.removeItem("reloading");
        renderItems();
      }
    };
  }
  initializeDomDescriptionContent() {
    let height = "";
    function addStickyProp(height) {
      content2.style.marginTop = "345px";
      textBox.classList.add("sticky-el");
      textBox.setAttribute("style", `height:${height - 30}px !important;`);
    }
    const setStickyEl = () => {
      let position = this.maxWidth.getBoundingClientRect();
      let content2 = document.getElementById("content2");
      let maxWidth = this.maxWidth.getBoundingClientRect().width;
      height == "" ? (height = textBox.getBoundingClientRect().height) : "";
      if (
        parseInt(position.top) < -118 &&
        !this.textBox.classList.contains("sticky-el")
      ) {
        maxWidth <= 798 ? addStickyProp(height) : "";
      }
      if (parseInt(position.top) > -118) {
        content2.style.marginTop = "2px";
        this.textBox.classList.remove("sticky-el");
      }
    };
    window.addEventListener("scroll", setStickyEl);
  }
  checkContent(content) {
    window.addEventListener("scroll", function () {
      content.forEach((item) => {
        item.getBoundingClientRect().top < (window.innerHeight / 5) * 3.5
          ? item.classList.add("show")
          : item.classList.remove("show");
      });
    });
  }
}
/*InternShip Page js start*/
const scrollItems = document.getElementById("scroll-items");
const leftScrollIcon = document.getElementById("scroll-left");
const rightScrollIcon = document.getElementById("scroll-right");
const box = document.querySelectorAll(".box");
const ui1 = new Ui(scrollItems, leftScrollIcon, rightScrollIcon, box);

leftScrollIcon !== null ? ui1.initializeDomInternContent() : "";

/*InternShip Page js end*/

// Description js start
let textBox = document.getElementById("text-box");
let maxWidth = document.getElementById("max-width");

const ui2 = new Ui(null, null, null, null, textBox, maxWidth);
textBox !== null ? ui2.initializeDomDescriptionContent() : "";

// Description js end
// Home js start
const aboutContent = document.querySelectorAll(".about-content");
const ui3 = new Ui();
aboutContent !== null ? ui3.checkContent(aboutContent) : "";
// Home js end
