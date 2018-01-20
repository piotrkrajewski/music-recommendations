$(document).ready(function () {
    function resultProcessor(data) {
        return {
            results: data
        };
    }

    function formatState(state) {
        if (!state.imageUrl) {
            return state.text;
        }

        var $artistImage = $('<div>');
        $artistImage.addClass('suggestion-image');
        $artistImage.attr('style', 'background-image:url("' + state.imageUrl + '");');

        var $text = $('<span>');
        $text.addClass('suggestion-text');
        $text.append(state.text);

        var $span = $('<span>');
        $span.addClass('suggestion-container');
        $span.append($artistImage);
        $span.append($text);

        return $span;
    };

    let select2Config = {
        placeholder: 'Select your favorite artists or genres',
        width: '100%',
        minimumInputLength: 1,
        maximumSelectionLength: 5,
        templateResult: formatState,
        ajax: {
            url: '/seed-elements-suggestions',
            dataType: 'json',
            data: function (params) {
                return {
                    query: params.term,
                }
            },
            processResults: resultProcessor
        }
    };

    $('.js-search-box').select2(select2Config);
});