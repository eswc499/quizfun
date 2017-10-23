<$('#pagination-demo').twbsPagination({
    totalPages: 5,
    // the current page that show on start
    startPage: 1,

    // maximum visible pages
    visiblePages: 5,

    initiateStartPageClick: true,

    // template for pagination links
    href: false,

    // variable name in href template for page number
    hrefVariable: '{{number}}',

    // Text labels
    first: 'First',
    prev: 'Previous',
    next: 'Next',
    last: 'Last',

    // carousel-style pagination
    loop: false,

    // callback function
    onPageClick: function (event, page) {
        $('.page-active').removeClass('page-active');
        $('#page' + page).addClass('page-active');
    },

    // pagination Classes
    paginationClass: 'pagination',
    nextClass: 'next',
    prevClass: 'prev',
    lastClass: 'last',
    firstClass: 'first',
    pageClass: 'page',
    activeClass: 'active',
    disabledClass: 'disabled'

});

function htmlbodyHeightUpdate() {
    var height3 = $(window).height()
    var height1 = $('.nav').height() + 50
    height2 = $('.main').height()
    if (height2 > height3) {
        $('html').height(Math.max(height1, height3, height2) + 10);
        $('body').height(Math.max(height1, height3, height2) + 10);
    }
    else {
        $('html').height(Math.max(height1, height3, height2));
        $('body').height(Math.max(height1, height3, height2));
    }

}
$(document).ready(function () {
    htmlbodyHeightUpdate()
    $(window).resize(function () {
        htmlbodyHeightUpdate()
    });
    $(window).scroll(function () {
        height2 = $('.main').height()
        htmlbodyHeightUpdate()
    });
});

function move() {
    var elem = document.getElementById("myBar");
    var width = 0;
    var id = setInterval(frame, 50);
    function frame() {
        if (width >= 100) {
            clearInterval(id);
            document.getElementById("myP").className = "w3-text-green w3-animate-opacity";
            document.getElementById("myP").innerHTML = "Successfully uploaded 10 photos!";
        } else {
            width++;
            elem.style.width = width + '%';
            var num = width * 1 / 10;
            num = num.toFixed(0)
            document.getElementById("demo").innerHTML = num;
        }
    }
}



var modal = document.getElementById('id01');

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

var slideIndex = 0;
showSlides();

function showSlides() {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("dot");
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slideIndex++;
    if (slideIndex > slides.length) { slideIndex = 1 }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
    setTimeout(showSlides, 2000); // Change image every 2 seconds

    function openWin() {
        myWindow = window.open("", "myWindow", "width=200, height=100");   // Opens a new window
    }

    function closeWin() {
        myWindow.close();   // Closes the new window
    }

    function windowClose() {
        window.open('', '_parent', '');
        window.close();
    }

    var bd = document.getElementById('bdy');
    var btx = document.getElementById('bts');

    function resol() {
        if (bd.width == '200') {
            btx.style.width = '20';
        }
        
    }


    function popitup(url) {
        newwindow = window.open(url, 'name', 'height=200,width=150');
        if (window.focus) { newwindow.focus() }
        return false;
    }