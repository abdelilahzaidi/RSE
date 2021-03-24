
$(function () {
    $('ul.nav.navbar-nav').append('<li><div id="detailNavBar">Détails</div></li>');
    $(document).on('click', '#detailNavBar', function () {
        console.log('Click');
        $('.navbar').toggleClass('open');
    });
});