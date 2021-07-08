onload = () => {
    let x = document.getElementsByClassName("validation-message");
    for (let item of x) {
        if (item.textContent || 0 !== item.textContent.length) {
            item.textContent = "*";
        }
    }
}