function requestReview() {
    const userName = prompt('Как вас зовут?');
    if (userName === null || userName.trim() === '') {
        return;
    }

    const comment = prompt('Напишите ваш отзыв о LifeSpot');
    if (comment === null || comment.trim() === '') {
        return;
    }

    appendReview(userName.trim(), comment.trim(), new Date());
}

const appendReview = (userName, comment, createdAt) => {
    const reviews = document.querySelector('#reviews');
    reviews.querySelector('.empty-reviews')?.remove();

    const article = document.createElement('article');
    article.className = 'review';

    const heading = document.createElement('h3');
    heading.textContent = userName;

    const date = document.createElement('time');
    date.dateTime = createdAt.toISOString();
    date.textContent = createdAt.toLocaleString('ru-RU');

    const text = document.createElement('p');
    text.textContent = comment;

    article.append(heading, date, text);
    reviews.prepend(article);
};

document
    .querySelector('#add-review')
    ?.addEventListener('click', requestReview);

const slides = [...document.querySelectorAll('.slide')];
let activeSlide = 0;

const showSlide = (index) => {
    activeSlide = (index + slides.length) % slides.length;

    slides.forEach((slide, slideIndex) => {
        const isActive = slideIndex === activeSlide;
        slide.hidden = !isActive;
        slide.setAttribute('aria-hidden', String(!isActive));
    });
};

document
    .querySelector('#previous-slide')
    ?.addEventListener('click', () => showSlide(activeSlide - 1));

document
    .querySelector('#next-slide')
    ?.addEventListener('click', () => showSlide(activeSlide + 1));

if (slides.length > 0) {
    showSlide(0);
}
