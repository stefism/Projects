<template>
  <div class="grid" v-loading="isLoading">
    <el-card
      :body-style="{ padding: '0px' }"
      v-for="book in books"
      :key="book.id"
    >
      <img :src="book.volumeInfo.imageLinks.smallThumbnail" class="image" />
      <div style="padding: 14px;">
        <h2>{{ getTitle(book.volumeInfo.title) }}</h2>
        <div class="bottom clearfix">
          <el-tag
            type="success"
            class="tag"
            v-for="(cat, i) in book.volumeInfo.categories"
            :key="book.id + i"
            >{{ cat }}</el-tag
          >
        </div>
      </div>

      <el-button type="primary" @click="onBookClick(book.id)">View more</el-button>
    </el-card>
  </div>
</template>

<script>
export default {
  props: {
    isLoading: Boolean,
    books: {
      type: Array,
      default: () => [],
    },
  },
  methods: {
    getTitle(title) {
      return title.length > 60 ? title.substring(0, 60) + " ..." : title;
    },
    onBookClick(bookId) {
      //Редиректваме към друг адрес през раутера. Пушваме в хисторито новия адрес. Този адрес трябва да е регистриран в раутовете за да работи.
      this.$router.push({ 
        name: 'bookDetails', 
        params: { bookId }, //Параметъра се ползва когато искаме да намерим нещо.
        query: { bookId, qq: 'Simo' } //Куерито се ползва, когато искаме да филтрираме нещо.
        });
        //                                  | параметър  |  куери
        //http://localhost:8080/book-details/YZZ9AAAAMAAJ?bookId=YZZ9AAAAMAAJ&qq=Simo
    }
  },
};
</script>

<style scoped>
.grid {
  display: grid;
  grid-template-columns: repeat(5, 1fr);
  grid-template-rows: repeat(4, 1fr);
  grid-column-gap: 12px;
  grid-row-gap: 12px;
}
</style>