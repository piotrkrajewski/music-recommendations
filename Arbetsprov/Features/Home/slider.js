$(document).ready(function () {
    let $slider = $('.slider');

    $slider.slider({
        step: 1,
        min: 0,
        max: 100,
        value: 100
    });

    $slider.on('change', function (slideEvent) {
        $('.slider-value').text(slideEvent.value.newValue);
    });
});