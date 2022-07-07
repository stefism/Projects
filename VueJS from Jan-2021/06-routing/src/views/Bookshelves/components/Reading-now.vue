<template>
  <div>
    <h1>Books readed now</h1>
    <BooksGrid :isLoading="isLoading" :books="books" />
  </div>
</template>

<script>
import BooksGrid from "@/components/Books-Grid.vue";
import { fetchReadingBooks } from "@/dataProviders/books.js";
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
  async created() {
    const { items } = await fetchReadingBooks();
    
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