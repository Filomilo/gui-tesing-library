package com.example.javafx_demo;

import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.Scene;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.control.*;
import javafx.scene.input.MouseDragEvent;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.Pane;
import javafx.scene.layout.StackPane;
import javafx.scene.paint.Color;
import javafx.stage.Modality;
import javafx.stage.Stage;

public class HelloController {

    @FXML private TextField titleTexField;
    @FXML private Button chnageTitleBUtton;
    @FXML private Pane SliderColorPane;
    @FXML private Slider resSlider;
    @FXML private Slider GreenSlider;
    @FXML private Slider BlueSlider;
    @FXML private TextArea textAreaTest;
    @FXML private Pane ColorButtonPane;
    @FXML private Canvas CanvasPane;
    @FXML private GridPane OperatorGridPane;

    float rSlider=0;
    float gSlider=0;
    float bSlider=0;
    @FXML
    public void initialize() {
        // Ensuring resSlider is initialized before adding a listener
        ChangeListener sliderChange=new ChangeListener<Number>() {
            @Override
            public void changed(ObservableValue<? extends Number> observable, Number oldValue, Number newValue) {
                onSliderChange();
            }
        };
        resSlider.valueProperty().addListener(sliderChange);
        BlueSlider.valueProperty().addListener(sliderChange);
        GreenSlider.valueProperty().addListener(sliderChange);






        GraphicsContext gc = CanvasPane.getGraphicsContext2D();
        gc.setStroke(Color.BLACK);
        gc.setLineWidth(2);

        CanvasPane.addEventHandler(MouseEvent.MOUSE_PRESSED, event -> {
            gc.beginPath();
            gc.moveTo(event.getX(), event.getY());
            gc.stroke();
        });

        CanvasPane.addEventHandler(MouseEvent.MOUSE_DRAGGED, event -> {
            gc.lineTo(event.getX(), event.getY());
            gc.stroke();
        });

        CanvasPane.widthProperty().bind(OperatorGridPane.widthProperty());

        CanvasPane.heightProperty().bind(OperatorGridPane.heightProperty());
//        textAreaTest.widthProperty().bind(OperatorGridPane.widthProperty());
//
//        textAreaTest.heightProperty().bind(OperatorGridPane.heightProperty());


    }

    public void CHANGE__TITLE_ACTION(ActionEvent actionEvent) {
        Stage stage = (Stage) chnageTitleBUtton.getScene().getWindow();
        stage.setTitle(titleTexField.getText());
    }
    public void updateSLliferPanelColro()
    {
        int r= (int) (255*rSlider);
        int g= (int) (255*gSlider);
        int b= (int) (255*bSlider);
        String style="-fx-background-color: rgba("+r+","+g+","+b+",1);";
        this.SliderColorPane.setStyle(style);

    }
    public void onSliderChange()
    {
        rSlider= (float) resSlider.getValue();
        bSlider= (float) BlueSlider.getValue();
        gSlider= (float) GreenSlider.getValue();
        updateSLliferPanelColro();
    }


    public void redMouseDrag(MouseDragEvent mouseDragEvent) {


    }

    public void OnOpenModalButton(ActionEvent actionEvent) {
        Stage parentStage = (Stage) chnageTitleBUtton.getScene().getWindow();
        Stage modalStage = new Stage();
        modalStage.initModality(Modality.APPLICATION_MODAL); // Blocks interaction with main window
        modalStage.initOwner(parentStage); // Set parent window

        Button closeButton = new Button("Close");
        closeButton.setOnAction(e -> modalStage.close());

        StackPane modalLayout = new StackPane(closeButton);
        Scene modalScene = new Scene(modalLayout, 250, 150);

        modalStage.setTitle("Modal Window");
        modalStage.setScene(modalScene);
        modalStage.showAndWait();
    }

    public void onWhiteButtonChange(ActionEvent actionEvent) {
        ColorButtonPane.setStyle("-fx-background-color: white;");
    }

    public void onBlackButtonChange(ActionEvent actionEvent) {
        ColorButtonPane.setStyle("-fx-background-color: black;");
    }

    public void onGreenButtonChange(ActionEvent actionEvent) {
        ColorButtonPane.setStyle("-fx-background-color: green;");
    }




}


