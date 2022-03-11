import { showSection } from "./dom.js";
//При импортирането на нещо от даден файл, файла се зарежда и ако има нещо на топ левел във файла, браузъра ще го изпълни.

const homeSection = document.getElementById('homeSection');
homeSection.remove();

const aboutSection = document.getElementById('aboutSection');
aboutSection.remove();

export function showHomePage() {
    showSection(homeSection);
}

export function showAboutPage() {
    showSection(aboutSection);
}