let currContext = null;

const section = document.getElementById('homePage');
section.remove();

section.querySelector('#getStartedLink').addEventListener('click', (e) => {
    e.preventDefault();
    currContext.goTo('catalog');
});

export async function showHomePage(context) {
    currContext = context;
    currContext.showSection(section);
}