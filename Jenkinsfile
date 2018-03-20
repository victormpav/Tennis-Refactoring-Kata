pipeline {
  agent any
  stages {
    stage('a') {
      steps {
        sleep 1
      }
    }
    stage('b') {
      parallel {
        stage('b') {
          steps {
            echo 'a'
          }
        }
        stage('') {
          steps {
            input 'hello'
          }
        }
      }
    }
  }
}