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

        if ($audio.data('id') != id) {
            $('.track-pause').removeClass('track-pause').addClass('track-play');

            $.get('/Track/LoadMusic/${id}')
                .done(data => {
                    $audio.prop('src', data);
                    $audio.data('id', id);
                    $audio[0].play();
                });
        } else {
            $audio[0].play();
        }

        $this.removeClass('track-play').addClass('track-pause');
    });
});