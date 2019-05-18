<?php

/* project/create.html.twig */
class __TwigTemplate_2a1b5d707aa72104692b6ffa1a05c4fb1e74d1bf350d67ef9d0e176233c33cfd extends Twig_Template
{
    public function __construct(Twig_Environment $env)
    {
        parent::__construct($env);

        // line 1
        $this->parent = $this->loadTemplate("base.html.twig", "project/create.html.twig", 1);
        $this->blocks = array(
            'main' => array($this, 'block_main'),
        );
    }

    protected function doGetParent(array $context)
    {
        return "base.html.twig";
    }

    protected function doDisplay(array $context, array $blocks = array())
    {
        $__internal_e3833d435043c2a7568b2a719a49e19244f4534b646fd2840531cec1889b98b7 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_e3833d435043c2a7568b2a719a49e19244f4534b646fd2840531cec1889b98b7->enter($__internal_e3833d435043c2a7568b2a719a49e19244f4534b646fd2840531cec1889b98b7_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "project/create.html.twig"));

        $__internal_4f3b8d3af9e65919a1339bf5306e262e66a92f35f1252694c31fa2846d270d52 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_4f3b8d3af9e65919a1339bf5306e262e66a92f35f1252694c31fa2846d270d52->enter($__internal_4f3b8d3af9e65919a1339bf5306e262e66a92f35f1252694c31fa2846d270d52_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "project/create.html.twig"));

        $this->parent->display($context, array_merge($this->blocks, $blocks));
        
        $__internal_e3833d435043c2a7568b2a719a49e19244f4534b646fd2840531cec1889b98b7->leave($__internal_e3833d435043c2a7568b2a719a49e19244f4534b646fd2840531cec1889b98b7_prof);

        
        $__internal_4f3b8d3af9e65919a1339bf5306e262e66a92f35f1252694c31fa2846d270d52->leave($__internal_4f3b8d3af9e65919a1339bf5306e262e66a92f35f1252694c31fa2846d270d52_prof);

    }

    // line 3
    public function block_main($context, array $blocks = array())
    {
        $__internal_59ba31d68552a911995bb8c500c513f90dc5886a264d2de13a323b13b16fcb66 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_59ba31d68552a911995bb8c500c513f90dc5886a264d2de13a323b13b16fcb66->enter($__internal_59ba31d68552a911995bb8c500c513f90dc5886a264d2de13a323b13b16fcb66_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        $__internal_9b47d97c472e05f92013ca8e8bf07e9261f7fd0b12e8d85b1ae2591688983f39 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_9b47d97c472e05f92013ca8e8bf07e9261f7fd0b12e8d85b1ae2591688983f39->enter($__internal_9b47d97c472e05f92013ca8e8bf07e9261f7fd0b12e8d85b1ae2591688983f39_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        // line 4
        echo "<div class=\"wrapper\">
    <form class=\"project-create\" method=\"post\">
        <div class=\"create-header\">
            Create Project
        </div>
        <div class=\"create-title\">
            <div class=\"create-title-label\">Title</div>
            <input class=\"create-title-content\" name=\"project[title]\" />
        </div>
        <div class=\"create-description\">
            <div class=\"create-description-label\">Description</div>
            <textarea rows=\"3\" class=\"create-description-content\" name=\"project[description]\"></textarea>
        </div>
        <div class=\"create-budget\">
            <div class=\"create-budget-label\">Budget</div>
            <input type=\"number\" min=\"0\" class=\"create-budget-content\" name=\"project[budget]\" />
        </div>

        ";
        // line 22
        echo $this->env->getRuntime('Symfony\Bridge\Twig\Form\TwigRenderer')->searchAndRenderBlock($this->getAttribute(($context["form"] ?? $this->getContext($context, "form")), "_token", array()), 'row');
        echo "

        <div class=\"create-button-holder\">
            <button type=\"submit\" class=\"submit-button\">Create Project</button>
            <a type=\"button\" href=\"/\" class=\"back-button\">Back</a>
        </div>


    </form>
</div>
";
        
        $__internal_9b47d97c472e05f92013ca8e8bf07e9261f7fd0b12e8d85b1ae2591688983f39->leave($__internal_9b47d97c472e05f92013ca8e8bf07e9261f7fd0b12e8d85b1ae2591688983f39_prof);

        
        $__internal_59ba31d68552a911995bb8c500c513f90dc5886a264d2de13a323b13b16fcb66->leave($__internal_59ba31d68552a911995bb8c500c513f90dc5886a264d2de13a323b13b16fcb66_prof);

    }

    public function getTemplateName()
    {
        return "project/create.html.twig";
    }

    public function isTraitable()
    {
        return false;
    }

    public function getDebugInfo()
    {
        return array (  69 => 22,  49 => 4,  40 => 3,  11 => 1,);
    }

    /** @deprecated since 1.27 (to be removed in 2.0). Use getSourceContext() instead */
    public function getSource()
    {
        @trigger_error('The '.__METHOD__.' method is deprecated since version 1.27 and will be removed in 2.0. Use getSourceContext() instead.', E_USER_DEPRECATED);

        return $this->getSourceContext()->getCode();
    }

    public function getSourceContext()
    {
        return new Twig_Source("{% extends \"base.html.twig\" %}

{% block main %}
<div class=\"wrapper\">
    <form class=\"project-create\" method=\"post\">
        <div class=\"create-header\">
            Create Project
        </div>
        <div class=\"create-title\">
            <div class=\"create-title-label\">Title</div>
            <input class=\"create-title-content\" name=\"project[title]\" />
        </div>
        <div class=\"create-description\">
            <div class=\"create-description-label\">Description</div>
            <textarea rows=\"3\" class=\"create-description-content\" name=\"project[description]\"></textarea>
        </div>
        <div class=\"create-budget\">
            <div class=\"create-budget-label\">Budget</div>
            <input type=\"number\" min=\"0\" class=\"create-budget-content\" name=\"project[budget]\" />
        </div>

        {{ form_row(form._token) }}

        <div class=\"create-button-holder\">
            <button type=\"submit\" class=\"submit-button\">Create Project</button>
            <a type=\"button\" href=\"/\" class=\"back-button\">Back</a>
        </div>


    </form>
</div>
{% endblock %}", "project/create.html.twig", "H:\\EXAM\\PHP-Skeleton\\app\\Resources\\views\\project\\create.html.twig");
    }
}
