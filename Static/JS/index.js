function filterContent() {
    const query = document
        .querySelector('#video-search')
        .value
        .trim()
        .toLowerCase();

    document.querySelectorAll('.video-container').forEach((video) => {
        const title = video
            .querySelector('.video-title')
            .textContent
            .toLowerCase();

        video.hidden = !title.includes(query);
    });
}

document
    .querySelector('#video-search')
    ?.addEventListener('input', filterContent);
