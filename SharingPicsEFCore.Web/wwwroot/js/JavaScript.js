$(() => {
    const canLike = $("#can-like").val();

    if (!canLike) {
        $("#like-button").append('disabled');
    }

    $("#like-button").on('click', function () {

    });

});