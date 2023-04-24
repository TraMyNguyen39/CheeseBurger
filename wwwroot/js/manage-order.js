const statusDetails = document.querySelectorAll('.main__status-details');

statusDetails.forEach(function (detail) {
    detail.addEventListener('click', function () {
        // Remove active class from previously active li element
        const currentActive = document.querySelector('.main__status-details.active');
        currentActive.classList.remove('active');

        // Add active class to the clicked li element
        this.classList.add('active');
    });
});
