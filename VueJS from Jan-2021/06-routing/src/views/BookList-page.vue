<template>
  <div>
    <h1>Magic Books</h1>
    <BooksGrid :isLoading="isLoading" :books="books" />
  </div>
</template>

<script>
import BooksGrid from "@/components/Books-Grid.vue";
import { fetchAllBooks } from "../dataProviders/books";
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
    this.books = await fetchAllBooks("magic");
    this.isLoading = false;
  },
};
</script>

<style scoped>
h2 {
  font-size: 18px;
}
</style>