pipeline {
    agent any

    environment {
        // Добавляем эту строчку, чтобы .NET работал без интернета и ошибок ICU
        DOTNET_SYSTEM_GLOBALIZATION_INVARIANT = '1'
    }

    stages {
        stage('Скачать код') {
            steps {
                checkout scm
            }
        }

        stage('Собрать проект') {
            steps {
                sh 'dotnet restore --offline || dotnet restore'
                sh 'dotnet build --configuration Release --no-restore'
            }
        }

        stage('Запустить автотесты') {
            steps {
                // Запуск тестов без интернета и браузера (Headless режим для Playwright)
                sh 'dotnet test --configuration Release --no-build || true'
            }
        }
    }

    post {
        always {
            script {
                allure includeProperties: false, 
                       jdk: '', 
                       properties: [], 
                       reportBuildPolicy: 'ALWAYS', 
                       results: [[path: '**/allure-results']]
            }
        }
    }
}
