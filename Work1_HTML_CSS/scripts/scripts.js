var indexValue = 0;
function slideShow() {
    setTimeout(slideShow, 5000)
    const imageArray = document.querySelectorAll('#image');
    for (let i = 0; i < imageArray.length; ++i) {
        imageArray[i].style.display = 'none';
    } 
    indexValue++;
    if(indexValue > imageArray.length) {
        indexValue = 1;
    }
    imageArray[indexValue -1].style.display = 'block';
}
slideShow();