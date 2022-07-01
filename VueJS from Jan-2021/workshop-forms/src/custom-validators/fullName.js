//Къстъм валидаторите трябва да връщат true или false на базата на нещо и после ги добавяме към модела на валидатора.

export function hasTwoNames(value) {
    const [firstName, lastName] = value.split(' ');
    return value.split(' ').length == 2 && firstName.length > 0 && lastName.length > 0;
}

export function isCapitalized(value) {
    const regex = /[A-Z]/;
    const [firstName, lastName] = value.split(' ');

    return regex.test(firstName.charAt(0)) && regex.test(lastName.charAt(0));
}

export function hasOnlyCharactersAndSpace(value) {
    const regex = /^[A-Za-z\s]+$/;
    return regex.test(value);
}