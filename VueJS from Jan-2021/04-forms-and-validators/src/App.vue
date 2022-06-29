<template>
  <div class="container d-flex pt-5">
    <form class="flex-fill">
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
          <h1>Registration</h1>
          <hr />
  
          <div class="form-group">
            <label for="email">Email</label>
            <input type="text" id="email" class="form-control"/>
          </div>

          <div class="form-group">
            <label for="password">Password</label>
            <input type="password" id="password" class="form-control"/>
          </div>

          <div class="form-group">
            <label for="age">Age</label>
            <input type="number" id="age" class="form-control"/>
          </div>

          <!---->
        </div>
      </div>
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 form-group">
          <label for="description">Description</label> <br />
          <textarea id="description" rows="5" class="form-control"></textarea>
        </div>
      </div>
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
          <div class="form-group">
            <h3>Skill Set</h3>
            <label for="js"><input type="checkbox" id="js" value="JavaScript"/>JavaScript</label>
            <label for="sharp"><input type="checkbox" id="sharp" value="C#"/>C#</label>
            <label for="java"><input type="checkbox" id="java" value="Java"/>Java</label>
            <label for="php"><input type="checkbox" id="php" value="PHP"/>PHP</label>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 form-group">
          <label for="male"><input type="radio" id="male" value="Male"/>Male</label>
          <label for="female"><input type="radio" id="female" value="Female"/>Female</label>
        </div>
      </div>
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 from-group">
          <label for="country">Country</label>
          <select id="country" class="form-control">
            <option>Bulgaria</option>
            <option>Germany</option>
            <option>England</option>
          </select>
        </div>
      </div>
      <hr />
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
          <button disabled="disabled" type="submit" class="btn btn-primary">Submit!</button>
        </div>
      </div>
    </form>
    <form class="flex-fill">
      <div class="row">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
          <div class="panel panel-default">
            <div class="panel-heading">
              <h4 class="panel-heading">Your Data</h4>
            </div>
            <div class="panel-body">
              <p>Mail:</p>
              <p>Password:</p>
              <p>Age:</p>
              <p>Description:</p>
              <p><strong>Skill Set?</strong></p>
              <ul>
                <li>C#</li>
                <li>JavaScript</li>
              </ul>
              <p>Gender:</p>
              <p>Country:</p>
            </div>
          </div>
        </div>
      </div>
    </form>
  </div>
</template>

<script>


export default {
  name: 'App',
  components: {
    
  }
}
</script>

<style>
  @import url("https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css");
</style>
