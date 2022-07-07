import BookDetails from '../views/BookDetails-page.vue';

const bookRoutes = [
    { path: '/magic-books', component: () => import('../views/BookList-page.vue') },
    //Този синтаксис е lazy loading. Импортваме компонента само когато се поиска. Прави се за да не се чака много в началото при стартирането на приложението.
    
    { path: '/book-details/:bookId', name: 'bookDetails', component: BookDetails },
    // :bookId - ако го напишем с ? накрая, го правим опционален - :bookId?
    // Можем да подаваме и повече от един параметър, примерно /:bookId'/:authorId, но тогава ще ги очаква параметрите в реда в който са подадени и не е добра идея да изпускаме първия примерно, ако има два.

    { path: '/bookshelves', redirect: '/bookshelves/favourites'},
    //Трябва да стои на това място този редирект. Така избягваме да виждаме междинния раут /bookshelves, който не показва нищо. Много е важно къде точно в масива от раутове ще се поставят редиректите. Ако не се поставят на правилното място, не работят.

    { 
        path: '/bookshelves', 
        name: 'bookshelves',
        beforeEnter: (to, from, next) => {
            console.log('Note - inside bookshelves');
            next();
        },
        //beforeEnter също идва от раут гарда.

        component: () => import('@/views/Bookshelves/Book-shelves.vue'),
        
        children: [
            {
                path: 'favourites', 
                name: 'favourites', 
                component: () => import('@/views/Bookshelves/components/Favourite-books.vue')
            },
            
            {
                path: 'reading', 
                name: 'reading', 
                component: () => import('@/views/Bookshelves/components/Reading-now.vue')
            }
        ]
    }
];

export default bookRoutes;