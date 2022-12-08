// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var container = document.getElementById("my-image-collection");
var button = document.getElementById("next-button");
var button1 = document.getElementById("previous-button");

//button.style.display = 'none'

//container.addEventListener('mouseenter', () => {
//    // show the button when the mouse is over the container
//    button.style.display = 'block';
//});

//container.addEventListener('mouseleave', () => {
//    // hide the button when the mouse is no longer over the container
//    button.style.display = 'none';
//});

button.addEventListener("click", function () {
    container.scrollTop += 400;
});
button1.addEventListener("click", function () {
    container.scrollTop -= 400;
});
