<template>
  <div>
    <h1>Favourite Books</h1>
    <BooksGrid :isLoading="isLoading" :books="books" />
  </div>
</template>

<script>
import BooksGrid from "@/components/Books-Grid.vue";
import { fetchFavouriteBooks } from "@/dataProviders/books.js";
export default {
  components: {
    BooksGrid,
  },
  data() {
    return {
      isLoading: true,
      books: [],
    };
  },
  beforeRouteEnter(to, from, next) {
    console.log('Това е раут гард на ниво компонент.');
    //Може да се ползва и за да фечнем данни преди да сме отишли на съответния раут.
    next();
  },
  async created() {
    const { items } = await fetchFavouriteBooks();
    
    this.books = items;
    this.isLoading = false;
  },
};
</script>

<style scoped>
h2 {
  font-size: 18px;
}
</style>