function notify(message) {
    let notification = document.getElementById('notification')
    notification.innerText = message
    notification.style.display = 'block'
    setTimeout(function () {
        notification.style.display = 'none'
    }, 2000)
}