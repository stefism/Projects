function cars(input) {
    let objects =[];

    input.forEach(car => {
        let [command, name, inheritOrProperty, inheritNameOrPropertyValue] = car.split(' ');

        if(command == 'create') {
            let newObject = {
                name: name,
                ownProperties: [],
                inheritProperties: [],
                parentFor: []
            };

            if(inheritOrProperty) {
                let parent = objects.find(o => o.name == inheritNameOrPropertyValue);
                parent.parentFor.push(name);
            }

            objects.push(newObject);

        } else if(command == 'set') {
            let object = objects.find(o => o.name == name);
            object.ownProperties.push(`${inheritOrProperty}:${inheritNameOrPropertyValue}`);

            // if(object.parentFor.length > 0) {
            //     object.parentFor.forEach(childObjectName => {
            //         let childObj = objects.find(o => o.name == childObjectName);
            //         childObj.inheritProperties.push(`${inheritOrProperty}:${inheritNameOrPropertyValue}`);
            //     });
            // }

        } else if(command == 'print') {
            objects.forEach(obj => {
                if(obj.parentFor.length > 0) {
                    obj.parentFor.forEach(childObjectName => {
                        let childObj = objects.find(o => o.name == childObjectName);
                        childObj.inheritProperties.push(...obj.ownProperties);
                    });
                }
            });

            let object = objects.find(o => o.name == name);
            
            let result = '';

            if(object.inheritProperties.length > 0) {
                result = object.ownProperties.join(',') + ',';
                result += object.inheritProperties.join(',');

            } else if (object.ownProperties.length == 0) {
                result += object.inheritProperties.join(',');
            
            } else {
                result = object.ownProperties.join(',');
            }
            
            console.log(result);
        }
    });
}

cars(['create pesho','create gosho inherit pesho','create stamat inherit gosho','set pesho rank number1','set gosho nick goshko','print stamat']);