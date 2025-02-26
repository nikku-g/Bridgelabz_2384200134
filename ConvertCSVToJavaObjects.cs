import com.opencsv.bean.CsvToBean;
import com.opencsv.bean.CsvToBeanBuilder;
import com.opencsv.bean.CsvBindByName;
import java.io.FileReader;
import java.io.Reader;
import java.util.List;

public class CSVToJavaObjects {
    public static void main(String[] args) {
        String csvFile = "students.csv";

        try (Reader reader = new FileReader(csvFile)) {
            // Convert CSV to Java Objects
            CsvToBean<Student> csvToBean = new CsvToBeanBuilder<Student>(reader)
                    .withType(Student.class)
                    .withIgnoreLeadingWhiteSpace(true)
                    .build();

            // Store students in a list
            List<Student> students = csvToBean.parse();

            // Print student details
            System.out.println("Student Records:");
            for (Student student : students) {
                System.out.println(student);
            }

        } catch (Exception e) {
            System.err.println("Error reading CSV: " + e.getMessage());
        }
    }

    // Student Class with CSV Annotations
    public static class Student {
        @CsvBindByName(column = "ID")
        private int id;
        
        @CsvBindByName(column = "Name")
        private String name;
        
        @CsvBindByName(column = "Age")
        private int age;
        
        @CsvBindByName(column = "Email")
        private String email;

        // Getters and Setters
        public int getId() { return id; }
        public void setId(int id) { this.id = id; }

        public String getName() { return name; }
        public void setName(String name) { this.name = name; }

        public int getAge() { return age; }
        public void setAge(int age) { this.age = age; }

        public String getEmail() { return email; }
        public void setEmail(String email) { this.email = email; }

        @Override
        public String toString() {
            return "ID: " + id + ", Name: " + name + ", Age: " + age + ", Email: " + email;
        }
    }
}