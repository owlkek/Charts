// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(() => {
    const $audio = $('audio');

    $audio
        .on('play', event => {
            const id = $audio.data('id');
            $('#' + id).removeClass('track-play').addClass('track-pause');
        })
        .on('pause', event => {
            const id = $audio.data('id');
            $('#' + id).removeClass('track-pause').addClass('track-play');
        });

    $('.track').click(x => {
        const $this = $(x.target);

        if ($this.hasClass('track-pause')) {
            $audio[0].pause();
            return;
        }

        const id = $this.prop('id');

        if ($audio.data('id') !== id) {
            $('.track-pause').removeClass('track-pause').addClass('track-play');

            $.get(`/Track/LoadMusic/${id}`)
                .done(data => {
                    $audio.prop('src', data);
                    $audio.data('id', id);
                    $audio[0].play();
                }).fail(x => { console.log(x) });
        } else {
            $audio[0].play();
        }

        $this.removeClass('track-play').addClass('track-pause');
    });
});
