function systemComponents(input) {
    let catalogue = {}

    for(let line of input){
        let [systemName, componentName, subCompName] = line.split(' | ')

        if(!catalogue.hasOwnProperty(systemName)){
            catalogue[systemName] = {}
        }

        let components = catalogue[systemName]

        if(!components.hasOwnProperty(componentName)){
            components[componentName] = []
        }

        let subComponents = components[componentName]

        if(!subComponents.some(x => x === subCompName)){
            subComponents.push(subCompName)
        }
    }

    let output = ''

    let entries = Object.entries(catalogue)

    for(object in catalogue){

    }

    console.log(catalogue)
}

console.log(systemComponents(['SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security']
))