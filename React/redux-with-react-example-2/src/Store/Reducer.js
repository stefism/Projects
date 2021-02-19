const initialState = {
    message: 'Click on the button.'
};

const reducer = (state = initialState, actions) => {
    const newState = {...state}

    if(actions.type === 'Message change') {
        newState.message = 'Button is clicked'
    }

    return newState
};

export default reducer;