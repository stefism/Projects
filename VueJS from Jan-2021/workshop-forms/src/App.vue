<template>
  <div id="app">
    <div class="container">
      <form action="" method="post">
        <fieldset>
          <h1>Registration form</h1>
          <p class="field field-icon">
            <label for="username">
              <span><i class="fas fa-user"></i></span>
            </label>
            <input type="text" name="username" id="username" class="error" placeholder="Mark Ulrich">
          </p>

          <!-- if error -->
          <p class="error">Full name field is invalid</p>

          <p class="field field-icon">
            <label for="email">
              <span><i class="fas fa-envelope"></i></span>
            </label>
            <input type="text" name="email" id="email" placeholder="marg@gmial.com">
          </p>

          <p class="field field-icon">
            <label for="tel">
              <span><i class="fas fa-phone"></i></span>
            </label>
            <select name="tel" id="tel" class="tel">
              <option value="1">+359</option>
            </select>
            <input type="text" name="tel" id="tel" placeholder="888 888">
          </p>

          <p class="field field-icon">
            <label for="building">
              <span><i class="fas fa-building"></i></span>
            </label>
            <select name="building" id="building" class="building">
              <option value="1">Designer</option>
              <option value="2">Software Engineer</option>
              <option value="3">Accountant</option>
              <option value="4">Manager</option>
              <option value="5">Other</option>
            </select>
          </p>

          <p class="field field-icon">
            <label for="password">
              <span><i class="fas fa-lock"></i></span>
            </label>
            <input type="password" name="password" id="password" placeholder="******">
          </p>

          <p class="field field-icon">
            <label for="re-password">
              <span><i class="fas fa-lock"></i></span>
            </label>
            <input type="re-password" name="re-password" id="re-password" placeholder="******">
          </p>

          <p><button>Create Account</button></p>

          <p class="text-center">
            Have an account?
            <a href="">Log In</a>
          </p>
        </fieldset>
      </form>
    </div>
  </div>
</template>

<script>

export default {
  name: 'App',
  mounted() {
    const fontAwsomeScript = document.createElement('script');
    fontAwsomeScript.setAttribute('scr', 'https://kit.fontaewsome.com/3cd69e2433.js');

    document.head.appendChild(fontAwsomeScript);
  },
  components: {
    
  }
}
</script>

<style>
  @import url('./assets/style.css');
</style>
