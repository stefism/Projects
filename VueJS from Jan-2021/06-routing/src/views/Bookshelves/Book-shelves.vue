<template>
  <div>
    <el-tabs @tab-click="onTabClick">
        <el-tab-pane label="Favourites" name="favourites">Favourites</el-tab-pane>
        <el-tab-pane label="Reading" name="reading">Reading now</el-tab-pane>

        <router-view />
        <!-- Като нестваме раутове, пак трябва да имаме тага router-view -->
    </el-tabs>
  </div>
</template>

<script>
export default {
    methods: {
        onTabClick({ name }) {
            console.log('name', name);
            console.log('router', this.$router);

            if(this.$router.history.current.name != name) {
                this.$router.push({ name });
            }
            //Правим проверка дали вече не сме пушнали в хисторито този линк. Ако я няма тази проверка, в конзолата ще дава тази грешка:
            //Uncaught (in promise) NavigationDuplicated: Avoided redundant navigation to current location:
            //Че се опитваме два пъти да пушнем един и същи раут.
        }
    }
}
</script>

<style>

</style>