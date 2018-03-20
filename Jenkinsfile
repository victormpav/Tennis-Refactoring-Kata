pipeline {
  agent any
  stages {
    stage('Stage 1') {
      parallel {
        stage('Step 1') {
          steps {
            echo 'step 1: printMsg'
          }
        }
        stage('Step 2') {
          steps {
            input 'hello'
            echo 'b'
          }
        }
      }
    }
    stage('Stage 2') {
      steps {
        echo 'Finished'
      }
    }
  }
}