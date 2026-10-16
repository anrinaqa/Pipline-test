pipeline {
    agent any 

    stages {
        stage('Run Tests on Windows Host') {
            steps {
                echo 'Передаем команду на хост-компьютер...'
                // Магия: Дженкинс через локальную сеть стучится в ваш Windows PowerShell и запускает тесты
                // Замените путь C:/work/MyCompany.Tests на ваш, если он отличается
                sh 'curl -X POST http://docker.internal --data "cd C:/work/MyCompany.Tests && dotnet test --configuration Release"'
            }
        }
    }

    post {
        always {
            echo 'Собираем Allure отчет...'
            allure includeProperties: false, jdk: '', results: [[path: '/var/jenkins_home/workspace/local-project/MyCompany.Tests/bin/Release/net8.0/allure-results']]

        }
    }
}
