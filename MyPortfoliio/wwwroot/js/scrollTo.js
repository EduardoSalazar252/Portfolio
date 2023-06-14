function scrollToComponent(id) {
    console.log(id);
    var element = document.getElementById(id);
    console.log(element);
    element.scrollIntoView({ behavior: "smooth", block: "start", inline: "nearest" });

}