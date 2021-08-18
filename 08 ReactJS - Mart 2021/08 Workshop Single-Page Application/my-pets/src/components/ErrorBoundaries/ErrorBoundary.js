import React from 'react';

class ErrorBoundary extends React.Component { // Грешките с този метод на показване се показват само ако си на продъкшън среда. (Или трябва да сме го билднали и да пуснем билда).
    constructor(props) {
        super(props);

        this.state = {
            hasError: false
        }
    }

    static getDerivedStateFromError(error) { // Първо се случва този метод и работи като връща направо новия стейт.
        if (this.state.hasError) {
            return <h1>Some error is here.</h1>
        }

        return {
            hasError: true
        }
    }

    componentDidCatch(error, errorInfo) {
        console.log('Error: ', error, errorInfo);
    }

    render() {
        return this.props.children;
    }
}

export default ErrorBoundary;